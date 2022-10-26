using System;
using System.Collections.Generic;

using static System.Reflection.BindingFlags;

namespace KeLi.SkillPoint.Usages
{
    internal class EventUsage : IAnalyzers
    {
        public void ShowResult()
        {
            var text = Console.ReadLine();
            var form = new TestForm();

            if(text == "Show")
                form.Show();

            else
                form.Close();
        }

        private abstract class BaseForm
        {
            protected Component component;

            public void Show()
            {
                component.StartListening();
            }

            public void Close()
            {
                component.StopListening();
            }

            protected abstract void Initial();
        }

        protected sealed class Component : List<CustomControl>
        {
            public void StartListening()
            {
                foreach (var control in this)
                {
                    // If you want call this, please call this before the 'WaitInput' method.
                    control.ContentInput += control.OnContentInput;

                    // If call the 'WaitInput', cannot add any method for event after this.
                    control.StartListening();
                }
            }

            public void StopListening()
            {
                foreach (var control in this)
                    control.StopListening();
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
                    case "Exit":
                        StopListening();
                        break;
                    case "Base":
                        ContentInput -= OnContentInput;
                        break;
                    default:
                        Console.WriteLine($"You input {e} on {nameof(BaseForm)}.");
                        break;
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
                component = new Component();
                control = new CustomControl();
                control.ContentInput += OnContentInput;
                component.Add(control);
            }

            private void OnContentInput(object sender, string e)
            {
                switch (e)
                {
                    case "Exit":
                        control.StopListening();
                        break;
                    case "Test":
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