using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Helpers.Settings
{
    public class JwtSettings
    {
        /// <summary>
        /// Gets or Sets <see cref="JwtKey"/>
        /// </summary>
        public string JwtKey { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="JwtIssuer"/>
        /// </summary>
        public string JwtIssuer { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="JwtAudiences"/>
        /// </summary>
        public IList<string> JwtAudiences { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="JwtExpireDays"/>
        /// </summary>
        public double JwtExpireDays { get; set; }
    }
}
