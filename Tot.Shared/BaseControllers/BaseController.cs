using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tot.Shared.Reponses;

namespace Tot.Shared.BaseControllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult Response<T>(ServiceResponse<T> serviceResponse)
        {
            if (serviceResponse == null)
                return StatusCode(500, new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Beklenmeyen bir hata oluştu."
                });

            if (!serviceResponse.Success)
            {
                if (serviceResponse.Errors != null && serviceResponse.Errors.Any())
                    return BadRequest(serviceResponse);

                // NotFound veya genel başarısızlık
                return serviceResponse.Message.Contains("bulunamadı", StringComparison.OrdinalIgnoreCase)
                    ? NotFound(serviceResponse)
                    : BadRequest(serviceResponse);
            }

            return Ok(serviceResponse);
        }
    }
}
