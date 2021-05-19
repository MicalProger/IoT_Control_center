namespace IoT_Control_center
{
    public class ShowProrerty
    {
        public string propName;
        public string PropNameClear { get => propName; set => propName = value; }
        public string PropName { get => propName + " : "; }
        public string Val { get; set; }
    }
}
