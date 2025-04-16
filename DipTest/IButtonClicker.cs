using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipTest
{
    public interface IButtonClicker
    {
        Task AccepCookiesAsync();
        Task RejectCookiesAsync();
    }
}
