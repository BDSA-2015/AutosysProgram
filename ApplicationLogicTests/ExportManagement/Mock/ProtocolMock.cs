using System.Collections.Generic;
using System.Collections.ObjectModel;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement.Entities;

namespace ApplicationLogicTests.ExportManagement.Mock
{
    /// <summary>
    /// Class for creating mock Protocols used for testing purposes
    /// </summary>
    public class ProtocolMock
    {
        /// <summary>
        /// Creates a valid Protocol with all necessary information for 
        /// creating a file to be exported e.g. CSV files
        /// </summary>
        /// <returns></returns>
        public static Protocol CreateProtocolMock()
        {
            return new Protocol
            {
                StudyName = "Software Study",
                StudyDescription = "For fun",
                StudyPhases = CreatePhases()
            };
        }

       private static List<Phase> CreatePhases()
        {
            return new List<Phase>
            {
                new Phase
                {
                    ExclusionCriteria = CreateExclusionCriteria(),
                    InclusionCriteria = CreateInclusionCriteria(),
                    AssignedRole = CreateAssignedRoles(),
                    Tasks = CreateAssignedTasks(),
                    Reports = CreateReports()
                },
                new Phase
                {
                    ExclusionCriteria = CreateExclusionCriteria(),
                    InclusionCriteria = CreateInclusionCriteria(),
                    AssignedRole = CreateAssignedRoles(),
                    Tasks = CreateAssignedTasks(),
                    Reports = CreateReports()
                },
                new Phase
                {
                    ExclusionCriteria = CreateExclusionCriteria(),
                    InclusionCriteria = CreateInclusionCriteria(),
                    AssignedRole = CreateAssignedRoles(),
                    Tasks = CreateAssignedTasks(),
                    Reports = CreateReports()
                }
            };
        }

        private static List<Criteria> CreateExclusionCriteria()
        {
            return new List<Criteria>
            {
                new Criteria {Name = "Fruit Products", Description = "Not eatable"},
                new Criteria {Name = "Pricy Hardware", Description = "Unaffordable"},
                new Criteria {Name = "Bad stuff", Description = "Bad"}
            };
        }

        private static List<Criteria> CreateInclusionCriteria()
        {
            return new List<Criteria>
            {
                new Criteria {Name = "Windows", Description = "See the light"},
                new Criteria {Name = "Quality Hardware", Description = "Powerful"}
            };
        }

        private static Dictionary<Role, List<User>> CreateAssignedRoles()
        {
            return new Dictionary<Role, List<User>>
            {
                {
                    new Role {RoleType = Role.Type.Reviewer},
                    new List<User>
                    {
                        new User {Name = "Member1"}
                    }
                }
            };
        }

        private static Dictionary<TaskRequest, List<User>> CreateAssignedTasks()
        {
            return new Dictionary<TaskRequest, List<User>>
            {
                {
                    new TaskRequest {Description = "Review papers 1-200"},
                    new List<User>
                    {
                        new User {Name = "Member1"}
                    }
                }
            };
        }

        private static List<Paper> CreateReports()
        {
            var fieldTypes = new ReadOnlyCollection<string>(new List<string>
            {
                "author",
                "title",
                "year"
            });
            var fieldValues = new ReadOnlyCollection<string>(new List<string>
            {
                "Sam",
                "Sam Learns to Program",
                "2015"
            });

            var paper1 = new Paper("book", fieldTypes, fieldValues) {ResourceRef = "1"};
            var paper2 = new Paper("book", fieldTypes, fieldValues) {ResourceRef = "2"};
            var paper3 = new Paper("book", fieldTypes, fieldValues) {ResourceRef = "3"};

            return new List<Paper> {paper1, paper2, paper3};
        }

        public static string OutPut()
        {
            return "Study;Study Description;Phase;Exclusion Criteria;Inclusion Criteria;" +
                   "Assigned Tasks;Assigned Roles;Resources;" +
                   "Software Study;For fun;Phase1;Fruit Products,Pricy Hardware,Bad stuff,;" +
                   "Windows,Quality Hardware,;Review papers 1-200 done by Member1,;Member1 given role Reviewer,;" +
                   "1,2,3,;" +
                   "Software Study;For fun;Phase2;Fruit Products,Pricy Hardware,Bad stuff,;" +
                   "Windows,Quality Hardware,;Review papers 1-200 done by Member1,;Member1 given role Reviewer,;" +
                   "1,2,3,;" +
                   "Software Study;For fun;Phase3;Fruit Products,Pricy Hardware,Bad stuff,;" +
                   "Windows,Quality Hardware,;Review papers 1-200 done by Member1,;Member1 given role Reviewer,;" +
                   "1,2,3,;";
        }
    }
}
