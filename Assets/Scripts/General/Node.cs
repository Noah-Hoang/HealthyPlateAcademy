

public class Node 
{
    public int value;
    public Node nextNode;

    //This is a constructor which means that this method is called when the class is created
    //The parameters are set to their deafult (ex. null) so that  the value of the parameter can be optionally set when the class is created
    //The default means that if you don't change the value in the parameter when creating it, you will get the default as the value
    public Node(int tempValue, Node tempNextNode = null)
    {
        value = tempValue;
        nextNode = tempNextNode;
    }

    
}
