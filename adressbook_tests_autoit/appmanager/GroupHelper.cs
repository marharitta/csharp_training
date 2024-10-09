

namespace adressbook_tests_autoit
{
    public class GroupHelper: HelperBase
    {
        private const string DELGROUPWINTITLE = "Delete group";
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{Enter}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);

            // WinWait not works propely, add delay for 500ms to be sure that windows was opened
            Thread.Sleep(500);
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>(); 
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item  = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText", "#0|#"+i, "");

                list.Add(new GroupData()
                {
                    Name = item 
                });
      
            }

            CloseGroupsDialogue();
            return list;
        }

        public void DeletGroup(int id)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + id , "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");

            aux.WinWait(DELGROUPWINTITLE);
            aux.ControlClick(DELGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDialogue();
        }
    }
}