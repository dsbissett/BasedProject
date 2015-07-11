using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Based.Business.Core;
using Based.Business.Interfaces;
using Based.DataAccess;
using Based.DataAccess.Models;
using SharpRepository.Repository;

namespace Based.Business.Customers
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly IRepository<Detail> details;
        
        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="details"></param>
        public CustomerLogic(DetailRepository details)
        {
            this.details = details;            
        }

        /// <summary>
        /// Static constructor creates mappings once and only once
        /// </summary>
        static CustomerLogic()
        {
            Mapper.CreateMap<Detail, CustomerDto>();            
        }

        /// <summary>
        /// Gets CustomerDto of customer whose ID# matches the passed-in id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="ICustomerDto"/></returns>
        public ICustomerDto GetById(int id)
        {
            try
            {
                var query = details.Find(x => x.Id == id);

                if (query == null)
                {
                    return null;
                }

                var result = Mapper.Map<CustomerDto>(query);

                return result;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Allows paging CustomerDtos
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>  
        /// <returns><see cref="ICustomerPage"/></returns>
        public ICustomerPage GetPage(int pageNumber, int pageSize)
        {
            // Sort list..
            //var query = details.AsQueryable().OrderBy(x => x.Id);
            var query = details.AsQueryable().OrderBy(x => x.Id).Skip((pageSize * pageNumber) - pageSize).Take(pageSize).ToList();

            // Get total count..
            var totalCount = query.Count();

            // Get number of pages by applying Math.Ceiling:
            // Assume:  totalCount = 20, pageSize = 3
            // 20 / 3 = 6.6666 pages
            // Math.Ceiling(6.6666) -> 7 pages will contain results
            var totalPage = (int)Math.Ceiling((double)totalCount / pageSize);

            // Get page:
            // Assume:  pageSize = 10, pageNumber = 2, totalRecords = 20
            // ex:  (10 * 2) = 20, 20 records will be skipped and is incorrect.
            //      (10 * 2) = 20, subract 10 = 10 records will be skipped and is correct.
            //var list = query.Skip((pageSize * pageNumber) - pageSize).Take(pageSize).ToList();

            // Map dbo to DTO
            var results = Mapper.Map<List<CustomerDto>>(query);

            // Return custom object
            return new CustomerPage
            {
                Info = new Info
                {
                    CurrentPage = pageNumber,
                    Total       = totalCount,
                    TotalPages  = totalPage,
                    PageSize    = results.Count
                },
                Customers = results
            };
        }
    }
}