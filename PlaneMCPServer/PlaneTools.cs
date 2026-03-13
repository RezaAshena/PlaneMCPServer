using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace PlaneMCPServer
{
    [McpServerToolType]
    public class PlaneTools
    {
        [McpServerTool, Description("Gets all possible statuses that a work item can have,these statuses do note where a work item would be in a typical kanban flow.the state ids returned can be used with other tools such as creating work items ")]
        public static async Task<string> GetAllWorkItemStatuses(PlaneApiService planeApiService)
        {
            var statuses = await planeApiService.GetProjectStatesAsync();
            return JsonSerializer.Serialize(statuses);
        }
        [McpServerTool, Description("This tool allows for the creation of a work item in Plane,in the given state.")]
        public static async Task<string> CreateWorkItem(
            PlaneApiService planeApiService,
            [Description("The title or main headline for the work item - keep it brief")] string name,
            [Description("The detailed description of the work item, can include HTML formatting")] string description,
            [Description("The state ID representing the current status of the work item,derived from the GetAllworkItemStatuses tool")] string stateId
            )
        {
            var workItem = await planeApiService.CreateworkItemAsync(name, description, stateId);
            return JsonSerializer.Serialize(workItem);
        }
    }
}

