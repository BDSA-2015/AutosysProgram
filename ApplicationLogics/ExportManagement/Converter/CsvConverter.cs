// CSVConverter.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogics.ExportManagement.Interfaces;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement.Entities;

namespace ApplicationLogics.ExportManagement.Converter
{
    /// <summary>
    /// Class for converting export files to the CSV format according to the European standard using ; as a separator
    /// by following the standards described at https://en.wikipedia.org/wiki/Comma-separated_values
    /// </summary>
    public static class CsvConverter
    {
        /// <summary>
        /// Converts the given Protocol to a string using the CSV format which can be exported by an ExportHandler
        /// </summary>
        /// <param name="protocol">The Protocol which is to be exported</param>
        /// <returns></returns>
        public static string Convert(Protocol protocol)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(null, "The given Protocol cannot be null");
            }
            var builder = new StringBuilder();

            CreateColumns(builder);
            CreateRows(protocol, builder);

            return builder.ToString();
        }

        /// <summary>
        /// Creates the columns of the CSV file. The columns are based on the fields in a Study and its Phases
        /// </summary>
        /// <param name="builder">The given StringBuilder which appends the string to be exported</param>
        private static void CreateColumns(StringBuilder builder)
        {
            builder.Append("Study;Study Description;Phase;Exclusion Criteria;Inclusion Criteria;" +
                           "Assigned Tasks;Assigned Roles;Resources;");
        }

        /// <summary>
        /// Creates the rows of the CSV file. The Rows are based on the data kept in the fields of a Study and its Phases
        /// </summary>
        /// <param name="protocol">The given protocol to be exported</param>
        /// <param name="builder">The given StringBuilder which appends the string to be exported</param>
        private static void CreateRows(Protocol protocol, StringBuilder builder)
        {
            var i = 1;
            foreach (var phase in protocol.Phases)
            {
                builder.Append($"{protocol.StudyName};{protocol.Description};Phase{i++};");
                AppendCriteria(phase.ExclusionCriteria, builder);
                AppendCriteria(phase.InclusionCriteria, builder);
                AppendAssignedTasks(phase.AssignedTask, builder);
                AppendRoles(phase.AssignedRole, builder);
                AppendResources(phase.Reports, builder);
            }
        }

        /// <summary>
        /// Appends the Criteria of a specific Phase in accordance to the CSV standard.
        /// </summary>
        /// <param name="criteriaList">The given List of criteria from a specific Study Phase </param>
        /// <param name="builder">The given StringBuilder which appends the string to be exported</param>
        private static void AppendCriteria(IEnumerable<Criteria> criteriaList, StringBuilder builder)
        {
            if (!criteriaList.Any()) return;
            foreach (var criteria in criteriaList)
            {
                builder.Append($"{criteria.Name},");
            }
            builder.Append(";");
        }

        /// <summary>
        /// Appends the Tasks and the associated Users of a specific Phase in accordance to the CSV standard.
        /// </summary>
        /// <param name="taskMap">The given Dictionary of Tasks and their associated Users in a specific phase</param>
        /// <param name="builder">The given StringBuilder which appends the string to be exported</param>
        private static void AppendAssignedTasks(Dictionary<TaskRequest, List<User>> taskMap, StringBuilder builder)
        {
            if (!taskMap.Any()) return;
            foreach (var task in taskMap.Keys)
            {
                builder.Append($"{task.Description} done by ");
                foreach (var user in taskMap[task])
                {
                    builder.Append($"{user.Name},");
                }
            }
            builder.Append(";");
        }

        /// <summary>
        /// Appends the Roles and the associated Users of a specific Phase in accordance to the CSV standard.
        /// </summary>
        /// <param name="roleMap">The given Dictionary of Roles and their associated Users in a specific Phase</param>
        /// <param name="builder">The given StringBuilder which appends the string to be exported</param>
        private static void AppendRoles(Dictionary<Role, List<User>> roleMap, StringBuilder builder)
        {
            if (!roleMap.Any()) return;
            foreach (var role in roleMap.Keys)
            {
                foreach (var user in roleMap[role])
                {
                    builder.Append($"{user.Name} given role {role.RoleType},");
                }
            }
            builder.Append(";");
        }

        /// <summary>
        /// Appends the Resource Ids associated with Resources of a specific Phase in accordance to the CSV standard.
        /// </summary>
        /// <param name="papers">The given resource collection of Papers in a specific Phase</param>
        /// <param name="builder">The given StringBuilder which appends the string to be exported</param>
        private static void AppendResources(IEnumerable<Paper> papers, StringBuilder builder)
        {
            if (!papers.Any()) return;
            foreach (var paper in papers)
            {
                builder.Append($"{paper.ResourceRef},");
            }
            builder.Append(";");
        }
    }
}