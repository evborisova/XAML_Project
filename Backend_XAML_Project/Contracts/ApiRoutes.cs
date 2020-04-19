using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api/v1";

        public static class Assigments
        {
            public const string GetAll = Root + "/assignment";

            public const string Get = Root + "/assignment/{assignmentId}";

            public const string Create = Root + "/assignment";

            public const string Update = Root + "/assignment/{assignmentId}";

            public const string Delete = Root + "/assignment/{assignmentId}";
        }

        public static class Employees
        {

            public const string GetAllEmployees = Root + "/employees";

            public const string GetEmployee = Root + "/employees/{employeeId}";

            public const string CreateEmployee = Root + "/employees";

            public const string UpdateEmployee = Root + "/employees/{employeeId}";

            public const string DeleteEmployee = Root + "/employees/{employeeId}";

        }

        public static class Companies
        {

            public const string GetAllCompanies = Root + "/companies";

            public const string GetCompany = Root + "/companies/{companyId}";

            public const string CreateCompany = Root + "/companies";

            public const string UpdateCompany = Root + "/companies/{companyId}";

            public const string DeleteCompany = Root + "/companies/{companyId}";

        }

        public static class CompanyTypes
        {

            public const string GetAllCompanyTypes = Root + "/companytypes";

            public const string GetCompanyType = Root + "/companytypes/{companyTypeId}";

            public const string CreateCompanyType = Root + "/companytypes";

            public const string UpdateCompanyType = Root + "/companytypes/{companyTypeId}";

            public const string DeleteCompanyType = Root + "/companytypes/{companyTypeId}";

        }

        public static class Planners
        {
            public const string GetAllPlanners = Root + "/planners";

            public const string GetPlanner = Root + "/planners/{plannerId}";

            public const string CreatePlanner = Root + "/planners";

            public const string UpdatePlanner = Root + "/planners/{plannerId}";

            public const string DeletePlanner = Root + "/planners/{plannerId}";

        }
    }
}