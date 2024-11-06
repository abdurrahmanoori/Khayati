using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.Common.Response
{
    public class DeclareMessage
    {
        public static ValidationError NotFound = new() { Code = nameof(NotFound), Description = "Not Found" };
        public static ValidationError BadRequest = new() { Code = nameof(BadRequest), Description = "Bad Request" };
        // public static ValidationError NonEnterprise = new() { Code = nameof(NonEnterprise), Description = "TIN is not Enterprise" };

        // public static ValidationError TinApplicaionNotFound = new() { Code = nameof(TinApplicaionNotFound), Description = "Tin Application Not Found" };
        // 
        // public static ValidationError DoesNotRequireManualValidation = new() { Code = nameof(DoesNotRequireManualValidation), Description = "This tin applicatinon does require manual varifacation, so it cannot be viewed" };
        // 
        // public static ValidationError TinAllocated = new() { Code = nameof(TinAllocated), Description = "TIN allocated successfully." };
        // public static ValidationError RejectDublicate = new() { Code = nameof(RejectDublicate), Description = "TIN already exists." };
        // 
        // public static ValidationError ReturnForCorrection = new() { Code = nameof(ReturnForCorrection), Description = "Request returned to center for correction" };
        // public static ValidationError TINISNUll = new() { Code = nameof(TINISNUll), Description = "TIN Field is required" };
        // public static ValidationError TinAlreadyPrinted = new() { Code = nameof(TinAlreadyPrinted), Description = "TIN Already printed" };

    }
}
