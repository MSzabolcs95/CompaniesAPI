using CompaniesAPI.Application.Commands;
using CompaniesAPI.Application.CommandHandlers;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CompaniesAPI.Application.Queries;

namespace CompaniesAPI.API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Create a new company
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            if (command == null)
            {
                return BadRequest(new { message = "Invalid company data" });
            }

            try
            {
                var companyId = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetById), new { id = companyId }, companyId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Retrieve a company by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var company = await _mediator.Send(new GetCompanyByIdQuery(id));

                if (company == null)
                    return NotFound(new { message = "Company not found" });

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Retrieve a company by ISIN
        [HttpGet("isin/{isin}")]
        public async Task<IActionResult> GetByIsin(string isin)
        {
            try
            {
                var company = await _mediator.Send(new GetCompanyByIsinQuery(isin));

                if (company == null)
                    return NotFound(new { message = "Company not found" });

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Retrieve all companies
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var companies = await _mediator.Send(new GetAllCompaniesQuery());
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Update an existing company
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            try
            {
                await _mediator.Send(command);
                return NoContent(); // Successfully updated
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
