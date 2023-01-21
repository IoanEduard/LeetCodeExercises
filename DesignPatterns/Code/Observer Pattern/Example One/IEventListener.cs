using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Code.Observer_Pattern.Example_One
{
    public interface IEventListener
    {
        void Update(string filename);
    }
}
