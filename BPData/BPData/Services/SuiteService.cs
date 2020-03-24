using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Lists;

namespace BPData.Services
{
    public class SuiteService
    {
        /// <summary>
        /// Gets a list of suites spades,hearts,clubs,diamonds
        /// </summary>
        /// <returns></returns>
        public List<Suite> GetSuiteList()
        {
            return new SuiteList().GetSuites();
        }
    }
}
