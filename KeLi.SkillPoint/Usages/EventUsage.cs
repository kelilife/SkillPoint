using System;
using System.Collections.Generic;

using static System.Reflection.BindingFlags;

namespace KeLi.SkillPoint.Usages
{
    internal class EventUsage : IResult
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
            protected Compontent _compontent;

            public void Show()
            {
                _compontent.StartListening();
            }

            public void Close()
            {
                _compontent.StopListening();
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

                        var eventType = eventInfo.DeclaringType;
                        var fieldInfo = eventType.GetField(eventInfo.Name, Public | NonPublic | Instance | Static);

                        fieldInfo?.SetValue(this, null);
                    }
                }

                public void OnContentInput(object sender, string e)
                {
                    if (e == "exit")
                        StopListening();

                    else if (e == "base")
                        ContentInput -= OnContentInput;

                    else
                        Console.WriteLine($"You input {e} on {nameof(BaseForm)}.");
                }
            }
        }

        private class TestForm : BaseForm
        {
            private CustomControl _control;

            public TestForm()
            {
                Initial();
            }

            protected override void Initial()
            {
                _compontent = new Compontent();
                _control = new CustomControl();
                _control.ContentInput += OnContentInput;
                _compontent.Add(_control);
            }

            private void OnContentInput(object sender, string e)
            {
                if (e == "exit")
                    _control.StopListening();

                else if (e == "test")
                    _control.ContentInput -= OnContentInput;

                else
                    Console.WriteLine($"You input {e} on {nameof(TestForm)}.");
            }
        }
    }
}