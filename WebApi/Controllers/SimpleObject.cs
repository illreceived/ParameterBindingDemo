namespace ParameterBindingDemo
{
    public class SimpleObject {
        public string A { get; set; }
        public int B { get; set; }

        public override string ToString()
        {
            return $"a: {A}, b: {B}";
        }
    }

}