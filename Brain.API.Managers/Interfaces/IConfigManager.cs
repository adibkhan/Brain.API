using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brain.API.Managers.Interfaces
{
    public interface IConfigManager
    {
        string GetGroupFileFullPath();

        string GetPasswordFileFullPath();

    }
}
