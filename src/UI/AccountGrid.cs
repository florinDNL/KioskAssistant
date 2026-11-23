using kioskAssistant.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace kioskAssistant.UI
{
    /// <summary>Shared behaviour for the account/profile assignment grids.</summary>
    internal static class AccountGrid
    {
        private static readonly (AccountType Type, string Label)[] Labels =
        {
            (AccountType.GlobalProfile, "Global"),
            (AccountType.AutoLogon, "Auto"),
            (AccountType.User, "User"),
            (AccountType.LocalGroup, "[L]Group"),
            (AccountType.DomainGroup, "[D]Group"),
            (AccountType.AzureGroup, "[A]Group"),
        };

        public static string ToLabel(AccountType type) => Labels.First(l => l.Type == type).Label;

        public static AccountType FromLabel(string label) =>
            Labels.Any(l => l.Label == label)
                ? Labels.First(l => l.Label == label).Type
                : throw new ArgumentException($"Unknown account type '{label}'.", nameof(label));

        public static bool IsGroup(AccountType type) =>
            type is AccountType.LocalGroup or AccountType.DomainGroup or AccountType.AzureGroup;

        public static bool AllAssigned(DataGridView grid, int profileColumn) =>
            grid.Rows.Cast<DataGridViewRow>().All(r => r.Cells[profileColumn].Value != null);

        /// <summary>Generation is only allowed once every row has a profile assigned.</summary>
        public static void RefreshGenerateButton(DataGridView grid, int profileColumn, Button generateButton)
        {
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            generateButton.Enabled = grid.RowCount > 0 && AllAssigned(grid, profileColumn);
        }

        /// <summary>Clears the profile cell of every row assigned to <paramref name="profileId"/>.</summary>
        public static void Unassign(DataGridView grid, int profileColumn, string profileId)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[profileColumn].Value as string == profileId)
                {
                    row.Cells[profileColumn].Value = null;
                }
            }
        }

        public static string NewProfileId() => "{" + Guid.NewGuid().ToString().ToUpperInvariant() + "}";
    }
}
