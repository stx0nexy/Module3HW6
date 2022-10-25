using System;
using System.Threading.Tasks;

namespace Module3HW6
{
    public class Program
    {
        public static void Main()
        {
            var tcs = new TaskCompletionSource();

            var messageBox = new MessageBox();
            messageBox.WindowIsClosed += (state) =>
            {
                switch (state)
                {
                    case State.Ok:
                        Console.WriteLine("Підтверджено");
                        break;
                    case State.Cancel:
                        Console.WriteLine("Скасовано");
                        break;
                }

                tcs.SetResult();
            };

            messageBox.Open();

            tcs.Task.GetAwaiter().GetResult();
        }
    }
}
