using System.Collections.Generic;

namespace JJ.MedsUseInfographic.Data
{
    public interface IPillMomentRepository
    {
        IList<PillMoment> GetAll();
    }
}