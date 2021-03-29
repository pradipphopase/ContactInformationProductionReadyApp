using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionReadyApp_API.Environment
{
    public class ResponseMessage
    {
        internal static readonly string Code_BadRequest = "400";
        internal static readonly string Code_Ok = "200";
        internal static readonly string Code_Created = "201";
        internal static readonly string Code_NoContent = "204";
        internal static readonly string Code_NotFound = "404";

        internal static readonly string Message_NullBody = "Information Missing...";
        internal static readonly string Message_RecordCreated = "The record has been added successfully!!!";
        internal static readonly string Message_RecordUpdated = "The record has been updated successfully!!!";
        internal static readonly string Message_RecordDeleted = "The record has been deleted successfully!!!";
        internal static readonly string Message_RecordFound = "record found";
        internal static readonly string Message_RecordNotFound = "The contact information couldn't be found.";
        internal static readonly string Message_RecordAlreadyExists = "Already Exists";
        internal static readonly string Message_IncorrectContactStatus = "Contact status should be either active or inactive";
    }
}
