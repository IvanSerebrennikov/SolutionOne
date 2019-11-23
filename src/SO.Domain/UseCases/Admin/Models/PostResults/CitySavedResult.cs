using System;
using System.Collections.Generic;
using System.Text;
using SO.Domain.UseCases._Base.Models.PostResults;

namespace SO.Domain.UseCases.Admin.Models.PostResults
{
    public class CitySavedResult : PostResultBase
    {
        public int CityId { get; internal set; }
    }
}
