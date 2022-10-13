using System;
using System.Collections.Generic;

using static System.Reflection.BindingFlags;

namespace KeLi.SkillPoint.Usages
{
    internal class EventUsage : IAnalyzers
    {
        public void ShowResult()
        {
            var cmd = Console.ReadLine();
            var form = new TestForm();

            if(cmd == "show")
                form.Show();

            else
                form.Close();
        }

        private abstract class BaseForm
        {
            protected Compontent compontent;

            public void Show()
            {
                compontent.StartListening();
            }

            public void Close()
            {
                compontent.StopListening();
            }

            protected abstract void Initial();

            protected sealed class Compontent : List<CustomControl>
            {
                public void StartListening()
                {
                    foreach (var control in this)
                    {
                        if (control is CustomControl customControl)
                        {
                            // If you want call this, please call this before the 'WaitInput' method.
                            customControl.ContentInput += customControl.OnContentInput;

                            // If call the 'WaitInput', cannot add any method for event after this.
                            customControl.StartListening();
                        }
                    }
                }

                public void StopListening()
                {
                    foreach (var control in this)
                    {
                        if (!(control is CustomControl customControl))
                            continue;

                        customControl.StopListening();
                    }
                }
            }

            protected class CustomControl
            {
                public event EventHandler<string> ContentInput;

                public void StartListening()
                {
                    while (true)
                    {
                        if (ContentInput is null)
                            return;

                        ContentInput.Invoke(this, Console.ReadLine());
                    }
                }

                public void StopListening()
                {
                    var eventInfos = typeof(CustomControl).GetEvents(Public | NonPublic | Instance | Static);

                    foreach (var eventInfo in eventInfos)
                    {
                        if (!eventInfo.Name.Equals(nameof(ContentInput)))
                            continue;

                        eventInfo.DeclaringType?.GetField(eventInfo.Name, Public | NonPublic | Instance | Static)?.SetValue(this, null);
                    }
                }

                public void OnContentInput(object sender, string e)
                {
                    switch (e)
                    {
                        case "exit":
                            StopListening();
                            break;
                        case "base":
                            ContentInput -= OnContentInput;
                            break;
                        default:
                            Console.WriteLine($"You input {e} on {nameof(BaseForm)}.");
                            break;
                    }
                }
            }
        }

        private class TestForm : BaseForm
        {
            private CustomControl control;

            public TestForm()
            {
                Initial();
            }

            protected sealed override void Initial()
            {
                compontent = new Compontent();
                control = new CustomControl();
                control.ContentInput += OnContentInput;
                compontent.Add(control);
            }

            private void OnContentInput(object sender, string e)
            {
                switch (e)
                {
                    case "exit":
                        control.StopListening();
                        break;
                    case "test":
                        control.ContentInput -= OnContentInput;
                        break;
                    default:
                        Console.WriteLine($"You input {e} on {nameof(TestForm)}.");
                        break;
                }
            }
        }
    }
}