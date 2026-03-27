using Microsoft.AspNetCore.Mvc;
using Day64MiniProject.Services;
using Day64MiniProject.DTOs;
using AutoMapper;
using Day64MiniProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace Day64MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            var accounts = await _accountService.GetAllAccounts();
            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accounts));
        }

        // GET: api/accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            var account = await _accountService.GetAccountById(id);

            if (account == null)
                return NotFound();

            return Ok(_mapper.Map<AccountDto>(account));
        }

        // POST: api/accounts
        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAccount(CreateAccountdto dto)
        {
            var account = _mapper.Map<Account>(dto);

            var created = await _accountService.CreateAccount(account);

            return Ok(_mapper.Map<AccountDto>(created));
        }

        // POST: api/accounts/deposit
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _accountService.Deposit(dto.AccountId, dto.Amount);
            return Ok("Deposit successful");
        }

        // POST: api/accounts/withdraw
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _accountService.Withdraw(dto.AccountId, dto.Amount);
            return Ok("Withdraw successful");
        }
    }
}