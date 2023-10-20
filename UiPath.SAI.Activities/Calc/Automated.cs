using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UiPath.SAI.Activities.Calc
{
    public class Automated
    {
        protected Process _process;
        protected AutomationElement _root;

        private Dictionary<string, AutomationElement> _elements =
            new Dictionary<string, AutomationElement>();

        private Stopwatch stopwatch = new Stopwatch();

        protected void StartApp(string appName, string rootElem, int timeoutInMs = 5000)
        {
            _process = Process.Start(appName);
            stopwatch.Reset();
            stopwatch.Start();
            do
            {
                _root = AutomationElement.RootElement.FindFirst(
                    TreeScope.Children, new PropertyCondition(
                        AutomationElement.NameProperty, rootElem));
                Thread.Sleep(100);
            }
            while (_root == null &&
                stopwatch.ElapsedMilliseconds < timeoutInMs);
            if (_root == null)
                throw new TimeoutException(appName + " could not be started");
        }

        private WindowPattern GetWindowPattern(AutomationElement targetControl)
        {
            WindowPattern windowPattern = null;

            try
            {
                windowPattern =
                    targetControl.GetCurrentPattern(WindowPattern.Pattern)
                    as WindowPattern;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the WindowPattern control pattern
                return null;
            }
            // Make sure the element is usable.
            if (false == windowPattern.WaitForInputIdle(10000))
            {
                // Object not responding in a timely manner
                return null;
            }
            return windowPattern;
        }


        protected void QuitApp()
        {
            var  wp = GetWindowPattern(_root);
            wp.Close();
            //_process.CloseMainWindow();
            _process.Dispose();
        }

        protected void PushButton(string name)
        {
            GetInvokePattern(GetButton(name)).Invoke();
        }

        protected bool IsEnabled(AutomationElement element)
        {
            return (bool)element.GetCurrentPropertyValue(
                AutomationElement.IsEnabledProperty);
        }

        protected void WaitEnabled(AutomationElement element, int timeoutInMs)
        {
            stopwatch.Reset();
            stopwatch.Start();
            while (!IsEnabled(element) &&
                stopwatch.ElapsedMilliseconds < timeoutInMs)
				Thread.Sleep(10);
            stopwatch.Stop();
            if (!IsEnabled(element))
                throw new TimeoutException(
                    "Timed out when waiting the element to get enabled.");
        }

        protected InvokePattern GetInvokePattern(AutomationElement element)
        {
            WaitEnabled(element, 1000);

            return element.GetCurrentPattern(InvokePattern.Pattern) as
                InvokePattern;
        }

        protected AutomationElement GetButton(string name)
        {
            if (_elements.TryGetValue(name, out AutomationElement elem))
                return elem;
            var result = _root.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, name));
            if (result == null)
                throw new ArgumentException(
                    "No function button found with name: " + name);
            _elements.Add(name, result);
            return result;
        }

    }
}
