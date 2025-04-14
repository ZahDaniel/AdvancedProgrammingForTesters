using PageLibrary.Interfaces;

namespace PageLibrary
{
    public class LoginPageHelper : IClickable, IFillable
    {
        public void Click(string selector)
        {
            Console.WriteLine($"Clicking on {selector}");
        }

        public void Fill(string selector, string text)
        {
            Console.WriteLine($"Filling '{text}' in {selector}");
        }
    }
}