using Repozytorium.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    public interface ICVRepo
    {
        IQueryable<CVViewModel> PobierzCV();
    }
}