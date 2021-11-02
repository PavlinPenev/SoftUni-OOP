using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando
    {
        List<Mission> Missions { get; set; }
    }
}
