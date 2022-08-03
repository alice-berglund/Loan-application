using LoanApplicationAPI.Handlers;
using LoanApplicationAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationAPI.Controllers
{
    [ApiController]
    [Route("Loan Application")]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ICreateLoanApplicationHandler _createLoanApplicationHandler;
        private readonly IUpdateLoanApplicationHandler _updateLoanApplicationHandler;
        private readonly IDeleteLoanApplicationHandler _deleteLoanApplicationHandler;
        private readonly ILoadLoanApplicationDecisionHandler _loadLoanApplicationDecisionHandler;

        public LoanApplicationController(  
            ICreateLoanApplicationHandler createLoanApplicationHandler, 
            IUpdateLoanApplicationHandler updateLoanApplicationHandler, 
            IDeleteLoanApplicationHandler deleteLoanApplicationHandler,
            ILoadLoanApplicationDecisionHandler loadLoanApplicationDecisionHandler)
        {
            _createLoanApplicationHandler = createLoanApplicationHandler;
            _updateLoanApplicationHandler = updateLoanApplicationHandler;
            _deleteLoanApplicationHandler = deleteLoanApplicationHandler;
            _loadLoanApplicationDecisionHandler = loadLoanApplicationDecisionHandler;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateLoanApplication([FromBody] CreateLoanApplicationRequest createLoanApplicationRequest)
        {
            var result = await _createLoanApplicationHandler.Handler(createLoanApplicationRequest);

            return result.IsSuccess 
                ? Ok(result.Value.Id) 
                : BadRequest(result.ErrorMessage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoanApplication(Guid id, [FromBody] UpdateLoanApplicationRequest updateLoanApplicationRequest)
        {
            var result = await _updateLoanApplicationHandler.Handler(id, updateLoanApplicationRequest);

            if (result.IsSuccess)
                return NoContent();

            if (result.ErrorMessage == "No loan application found with this Id")
                return NotFound(result.ErrorMessage);

            return BadRequest(result.ErrorMessage);   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanApplication(Guid id)
        {
            var result = await _deleteLoanApplicationHandler.Handler(id);

            if (result.IsSuccess)
                return NoContent();

            if (result.ErrorMessage == "No loan application found with this Id")
                return NotFound(result.ErrorMessage);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanApplicationDecision(Guid id)
        {
            var result = await _loadLoanApplicationDecisionHandler.Handler(id);

            if (result.IsSuccess)
                return Ok(result.Value);

            if (result.ErrorMessage == "No loan application found with this Id")
                return NotFound(result.ErrorMessage);

            return BadRequest(result.ErrorMessage);
        }
    }
}