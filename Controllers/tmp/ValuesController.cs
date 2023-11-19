﻿using CoolMate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Filter;
using WebApplication1.Helpers;
using WebApplication1.Services;
using WebApplication1.Wrappers;

namespace CoolMate.Controllers.tmp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DBContext DBContext;
        private readonly UriService uriService;

        public ValuesController(DBContext DBContext, UriService uriService)
        {
            this.DBContext = DBContext;
            this.uriService = uriService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromQuery] PaginationFilter filter)
        {
            var enpointUri = $"{Request.Scheme}://{Request.Host}/api/Values";
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var productsWithItemsAndImages =
                await DBContext.Products
                .Include(p => p.ProductItems)
                .ThenInclude(t => t.ProductItemImages)
                .ToListAsync();
            foreach (var product in productsWithItemsAndImages)
            {
                // Select distinct items based on the "Color" property
                var uniqueItems = product.ProductItems.GroupBy(i => i.Color).Select(group => group.First()).ToList();

                product.ProductItems = uniqueItems;
            }

            var totalRecords = productsWithItemsAndImages.Count();

            var data = productsWithItemsAndImages
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize).ToList();

            var reponse = PaginationHelper.CreatePagedReponse(data, validFilter, totalRecords, uriService, enpointUri);
            return Ok(reponse);
        }
        [HttpGet("testuserandmode")]
        [Authorize(Roles = "mod,user")]
        public ActionResult GetTest()
        {
            return Ok(new Response<string>("user and mod"));
        }
        [HttpGet("testmod")]
        [Authorize(Roles = "mod")]
        public ActionResult GetTestmode()
        {
            return Ok(new Response<string>("mod"));
        }
    }
}