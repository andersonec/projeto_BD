using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using apiRest_bd.Data.ModelsViews;
using frontEnd_bd.Data;

namespace frontEnd_bd.Pages.Tickets
{
    public class TicketsListModel : PageModel
    {
        private readonly frontEnd_bd.Data.frontEnd_bdContext _context;

        public TicketsListModel(frontEnd_bd.Data.frontEnd_bdContext context)
        {
            _context = context;
        }

        public IList<IngressoDTOList> IngressoDTOList { get;set; }

        public async Task OnGetAsync()
        {
            IngressoDTOList = await _context.IngressoDTOList.ToListAsync();
        }
    }
}
