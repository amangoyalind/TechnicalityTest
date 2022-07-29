using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalityTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CCChargeController : ControllerBase
    {

        private readonly ApiDbContext _context;
        ICCChargeService cCChargeService;

        public CCChargeController(ApiDbContext context, ICCChargeService _cCChargeService)
        {
            _context = context;
            cCChargeService = _cCChargeService;
        }

        [HttpGet]
        public List<CCChargeViewModel> Get(int id)
        {
            // id is CustomerId

            return _context.CreditCardCharges.Where(c => c.CustomerId == id).Select(c =>
                new CCChargeViewModel { CustomerId = c.CustomerId, Amount = c.Amount }).ToList();
        }

        [HttpPost]
        public int CreateCCCharge(CCChargeViewModel model)
        {
            return cCChargeService.CreateCCCharge(model.CustomerId, model.Amount);
        }
    }
}
