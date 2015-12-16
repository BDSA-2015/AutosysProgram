using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Models;

namespace StorageTests.DatabaseIntegrationTests
{

    /// <summary>
    /// This class is used to create entities (Paper, DataField, Criteria, User, Phase) used in the creation of a study in the database integration test. 
    /// </summary>
    public class StudyTestData
    {

        public static StoredStudy CreateStudyMock()
        {
            return new StoredStudy
            {
                // Todo insert data from help functions 
                Description = "Study Description",
                Name = "Study Name",
                
            };
        }

        // datafield, user, phase

        public static List<StoredPaper> CreatePapers()
        {
            var fieldTypes = new List<string>
            {
                "author",
                "title",
                "year"
            };

            var fieldValues = new List<string>
            {
                "Sam",
                "Sam Learns to Program",
                "2015"
            };

            var paper1 = new StoredPaper
            {
                ResourceRef = "1",
                FieldTypes = fieldTypes,
                FieldValues = fieldValues,
                RequesteDataFields = CreateDatafields(),
                Type = "Article"
            };
            var paper2 = new StoredPaper
            {
                ResourceRef = "2",
                FieldTypes = fieldTypes,
                FieldValues = fieldValues,
                RequesteDataFields = CreateDatafields(),
                Type = "Article"
            };
            var paper3 = new StoredPaper
            {
                ResourceRef = "3",
                FieldTypes = fieldTypes, 
                FieldValues = fieldValues,
                RequesteDataFields = CreateDatafields(),
                Type = "Article"
            };

            return new List<StoredPaper> { paper1, paper2, paper3 };
        }

        public static List<StoredCriteria> CreateExclusionCriteria()
        {
            return new List<StoredCriteria>
            {
                new StoredCriteria
                {
                    Name = "Fruit Products",
                    Description = "Not eatable",
                    Value = "true",
                    Tag = "Title",
                    CriteriaType = StoredCriteria.CriteriaTypeOptions.Exclusion, 
                    ComparisonType = StoredCriteria.OperationOptions.Contains
                },
                new StoredCriteria
                {
                    Name = "Pricy Hardware",
                    Description = "Unaffordable",
                    Value = "true",
                    Tag = "Title",
                    CriteriaType = StoredCriteria.CriteriaTypeOptions.Exclusion,
                    ComparisonType = StoredCriteria.OperationOptions.Contains
                },
                new StoredCriteria
                {
                    Name = "Bad stuff",
                    Description = "Bad",
                    Value = "true",
                    Tag = "Title",
                    CriteriaType = StoredCriteria.CriteriaTypeOptions.Exclusion,
                    ComparisonType = StoredCriteria.OperationOptions.Contains
                }
            };
        }

        public static List<StoredCriteria> CreateInclusionCriteria()
        {
            return new List<StoredCriteria>
            {
                new StoredCriteria
                {
                    Name = "Windows",
                    Description = "See the light",
                    Value = "true",
                    Tag = "Title",
                    CriteriaType = StoredCriteria.CriteriaTypeOptions.Inclusion,
                    ComparisonType = StoredCriteria.OperationOptions.Contains
                },
                new StoredCriteria
                {
                    Name = "Quality Hardware",
                    Description = "Powerful",
                    Value = "true",
                    Tag = "Title",
                    CriteriaType = StoredCriteria.CriteriaTypeOptions.Inclusion,
                    ComparisonType = StoredCriteria.OperationOptions.Contains
                },
                new StoredCriteria
                {
                    Name = "Message",
                    Description = "Hello",
                    Value = "true",
                    Tag = "Title",
                    CriteriaType = StoredCriteria.CriteriaTypeOptions.Inclusion,
                    ComparisonType = StoredCriteria.OperationOptions.Contains
                }
            };
        }

        public static List<StoredUser> CreateUsers()
        {
            return new List<StoredUser>
            {
                new StoredUser
                {
                    Name = "UserName",
                    MetaData = "Researcher",
                },
                new StoredUser
                {
                    Name = "UserName",
                    MetaData =  "Researcher"
                },
                new StoredUser
                {
                    Name = "UserName",
                    MetaData = "Researcher"
                }
            };
        }

        public static List<StoredPhase> CreatePhases()
        {
            return new List<StoredPhase>
            {
                new StoredPhase
                {
                    AssignedRoles = CreateAssignedRoles(),
                    Tasks = CreateAssignedTasks(),
                    Description = "ReviewPhase",
                    IsFinished = "true",
                    Name = "PhaseOne",
                    RequestedDataFields = CreateDatafields()
                },
                new StoredPhase
                {
                    AssignedRoles = CreateAssignedRoles(),
                    Tasks = CreateAssignedTasks(),
                    Description = "ValidationPhase",
                    IsFinished = "false",
                    Name = "PhaseTwo",
                    RequestedDataFields = CreateDatafields()
                },
                new StoredPhase
                {
                    AssignedRoles = CreateAssignedRoles(),
                    Tasks = CreateAssignedTasks(),
                    Description = "ReviewPhase",
                    IsFinished = "false",
                    Name = "PhaseThree",
                    RequestedDataFields = CreateDatafields()
                }
            };
        }

        // A role is assigned to several users, each PhaseRole is a key/value pair where key is role and value is list of users 
        public static ICollection<PhaseRole> CreateAssignedRoles()
        {
            return new List<PhaseRole>
            {
                new PhaseRole
                {
                    Role = new StoredRole
                    {
                        Type = StoredRole.RoleTypeOptions.Reviewer
                    },
                    Users = new List<StoredUser>
                    {
                        new StoredUser { Name = "Member1" }
                    } 
                }
            };
        }

        // A task is assigned to several users, each PhaseTask is a key/value pair where key is task and value is list of users 
        public static List<PhaseTask> CreateAssignedTasks()
        {
            return new List<PhaseTask>
            {
                new PhaseTask
                {
                    User = new StoredUser {Name = "Member1" },
                    Tasks = new List<StoredTaskRequest>
                    {
                        CreateTaskRequest()
                    }
                }
            };
        }

        public static StoredTaskRequest CreateTaskRequest()
        {
            return new StoredTaskRequest
            {
                Type = StoredTaskRequest.TaskTypeOptions.Review,
                Description = "Review papers 1-200",
                IsFinished = false,
                RequestedDataFields = CreateDatafields(),
                ConflictingData = CreateFieldConflicts()
            };
        }

        public static List<TaskConflicts> CreateFieldConflicts()
        {
            return new List<TaskConflicts>
            {
                new TaskConflicts
                {
                    Task = CreateTaskRequest(),
                    Conflicts = CreateConflict()
                }
            };
        }

        public static List<StoredConflict> CreateConflict()
        {
            return new List<StoredConflict>
            {
                new StoredConflict
                {
                    Data = new List<string>
                    {
                        "Data"
                    }
                }
            };
        }

        public static List<StoredDataField> CreateDatafields()
        {
            return new List<StoredDataField>
            {
                new StoredDataField
                {
                    Name = "Software Engineering",
                    Description = "Is this paper about software engineering?",
                    Type = StoredDataField.DatafieldTypeOptions.Boolean,
                    FieldData = new List<string>
                    {
                        "FieldData"    
                    },
                    IsModifiable = "true"
                }
            };
        }

    }
    
}
