using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSelenium.Support
{
    public static class Utilities
    {
        public static bool GenericWait(Func<bool> waitFunction, TimeSpan timeout, bool throwExceptions = false)
        {
            var success = false;
            var limitDate = DateTime.Now.AddNanoseconds((long)timeout.TotalNanoseconds());
            do
            {
                try
                {
                    success = waitFunction.Invoke();
                }
                catch(Exception ex)
                {
                    if (throwExceptions)
                    {
                        throw;
                    }
                    else
                    {
                        Debug.WriteLine(ex);
                    }
                }

            } while (!success && DateTime.Now.Ticks < limitDate.Ticks);

            return success;
        }

        public static void GenericWait(Action waitFunction, TimeSpan timeout, bool throwExceptions = false)
        {
            var limitDate = DateTime.Now.AddNanoseconds((long)timeout.TotalNanoseconds());
            do
            {
                try
                {
                    waitFunction.Invoke();
                    break;
                }
                catch (Exception ex)
                {
                    if (throwExceptions)
                    {
                        throw;
                    }
                    else
                    {
                        Debug.WriteLine(ex);
                    }
                }

            } while (DateTime.Now.Ticks < limitDate.Ticks);
        }
    }
}
