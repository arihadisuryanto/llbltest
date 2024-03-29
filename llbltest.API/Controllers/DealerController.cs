﻿using AutoMapper;
using llbltest.Dtos;
using llbltest.EntityClasses;
using llbltest.Services;
using Microsoft.AspNetCore.Mvc;

namespace llbltest.API.Controllers
{
    [ApiController]
    public class DealerController : Controller
    {
        private readonly IDealerService _dealerService;
        private readonly IMapper _mapperConfig;
        private readonly IConfiguration _configuration;   
        public DealerController(IDealerService dealerService, IMapper mapperConfig, IConfiguration configuration) 
        { 
            _dealerService = dealerService;
            _mapperConfig = mapperConfig;
            _configuration = configuration;
        }

        [HttpGet("Dealers")]
        public async Task<IActionResult> GetDealers()
        {
            try
            {
                var dealersEntity = await _dealerService.GetDealersAsync();

                if (dealersEntity.Count > 0)
                {
                    var dealersDto = _mapperConfig.Map<List<DealerDto>>(dealersEntity);
                    return Ok(dealersDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddDealer")]
        public async Task<IActionResult> AddDealer([FromForm]DealerDto dealerDto)
        {
            try
            {
                var dealerEntity = _mapperConfig.Map<Dealer>(dealerDto);

                if (dealerEntity is not null)
                {
                    var result = await _dealerService.AddDealerAsync(dealerEntity, dealerDto.Attachment);
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("PutDealer")]
        public async Task<IActionResult> PutDealer(DealerDto dealerDto)
        {
            try
            {
                var dealerEntity = _mapperConfig.Map<Dealer>(dealerDto);

                if (dealerEntity is not null)
                {
                    var result = await _dealerService.PutDealerAsync(dealerEntity, dealerDto.Id);
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("DeleteDealer")]
        public async Task<IActionResult> DeleteDealer(int id)
        {
            try
            {
                var result = await _dealerService.DeleteDealerAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("DownloadDealerAttachment")]
        public async Task<IActionResult> DownloadDealerAttachment(int id)
        {
            try
            {
                var result = await _dealerService.DownloadAttachmentDealerAsync(id);
                if (result.Item1 != null)
                {
                    return File(result.Item1, result.Item2);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
