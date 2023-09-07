using System;
using BookIt.Api.Controllers.BaseController;
using BookIt.Core.Application.Feature.Authentication.UserFeature.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookIt.Api.Controllers.Authentication
{
	[Route("[controller]")]
	public class UserController : AppBaseController
    {
		private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpPost("[action]")]
		public async Task<IActionResult> Signup(SignupCommandRequest request)
		{
            var response = await _mediator.Send(request);
            return Ok(response);
		}
	}
}

