using Joke.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.BusinessLogic
{
    public class AppConfigBusinessLogic
    {
        private readonly AppConfigDataProvider appData;
        public AppConfigBusinessLogic()
        {
            appData = new AppConfigDataProvider();
        }
    }
}
