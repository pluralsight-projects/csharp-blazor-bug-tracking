using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using BugTrackerUI.Tests;

namespace M5_BugTrackerUI.Tests.AddDataValidationToForm
{
    public class M5_01_AddRequiredAttributesTests
    {
        [Fact(DisplayName = "Add Required Attributes @add-required-attributes")]
        public void AddRequiredAttributesTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                    + Path.DirectorySeparatorChar + "Bug.cs";

            Assert.True(File.Exists(filePath), "`Bug.cs` should exist in the project root.");

            var bug = TestHelpers.GetClassType("BugTrackerUI.Bug");

            var titleAttributes = bug.GetProperty("Title").GetCustomAttributesData();
            var titleRequired = titleAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            Assert.True(titleRequired != null, "The `Title` property of the `Bug` class should be marked with the `[Required]` attribute.");

            var descriptionAttributes = bug.GetProperty("Description").GetCustomAttributesData();
            var descriptionRequired = descriptionAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            Assert.True(descriptionRequired != null, "The `Description` property of the `Bug` class should be marked with the `[Required]` attribute.");

            var priorityAttributes = bug.GetProperty("Priority").GetCustomAttributesData();
            var priorityRequired = priorityAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            Assert.True(priorityRequired != null, "The `Priority` property of the `Bug` class should be marked with the `[Required]` attribute.");
        }
    }
}
