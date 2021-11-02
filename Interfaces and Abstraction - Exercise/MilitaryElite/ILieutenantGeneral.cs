using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral
    {
        List<Private> PrivatesUnderCommand { get; set; }
    }
}
