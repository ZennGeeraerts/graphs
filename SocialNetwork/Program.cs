using SocialNetwork;
using Graphs;
using Graphs.Algorithms;

// p0—p1—p2
// |     |
// p3—p4—p5
// |
// p6
// |
// p7

Graph<Person, Connection<Person>> graph = new Graph<Person, Connection<Person>>(true);
Person p0 = new Person(0, "Calderon");
Person p1 = new Person(1, "Whitmore");
Person p2 = new Person(2, "Novak");
Person p3 = new Person(3, "O'Donnell");
Person p4 = new Person(4, "Sato");
Person p5 = new Person(5, "Moretti");
Person p6 = new Person(6, "Kuznetsov");
Person p7 = new Person(7, "Ramirez");

graph.AddNode(p0);
graph.AddNode(p1);
graph.AddNode(p2);
graph.AddNode(p3);
graph.AddNode(p4);
graph.AddNode(p5);
graph.AddNode(p6);
graph.AddNode(p7);

graph.AddConnection(new Connection<Person>(p0, p1));
graph.AddConnection(new Connection<Person>(p0, p3));
graph.AddConnection(new Connection<Person>(p1, p2));

graph.AddConnection(new Connection<Person>(p3, p4));
graph.AddConnection(new Connection<Person>(p3, p6));
graph.AddConnection(new Connection<Person>(p3, p7));

graph.AddConnection(new Connection<Person>(p4, p2));
graph.AddConnection(new Connection<Person>(p4, p5));

graph.AddConnection(new Connection<Person>(p5, p4));
graph.AddConnection(new Connection<Person>(p5, p2));

Console.WriteLine("People:");
foreach (Person node in graph)
{
    Console.WriteLine(node);
}
Console.WriteLine();
DFS<Person, Connection<Person>> dfs = new DFS<Person, Connection<Person>>(graph);
List<Person> dfsResult = dfs.FindPath(p0, p5);
Console.WriteLine("Depth first search:");
foreach (Person node in dfsResult)
{
    Console.WriteLine(node);
}
Console.WriteLine();
BFS<Person, Connection<Person>> bfs = new BFS<Person, Connection<Person>>(graph);
List<Person> bfsResult = bfs.FindPath(p0, p5);
Console.WriteLine("Breadth first search:");
foreach (Person node in bfsResult)
{
    Console.WriteLine(node);
}
Console.WriteLine();
TarjanAlgorithm<Person, Connection<Person>> tarjanAlgorithm = new TarjanAlgorithm<Person, Connection<Person>>(graph);
var components = tarjanAlgorithm.FindStronglyConnectedComponents();

Console.WriteLine("Strongly connected components:");
foreach (List<Person> component in components)
{
    Console.WriteLine("Connected component: ");
    foreach (Person node in component)
    {
        Console.WriteLine(node);
    }
    Console.WriteLine();
}
Console.WriteLine();