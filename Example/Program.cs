using Thabe.Kit.EasyChatGPT;
using Thabe.Kit.EasyChatGPT.Model.Data;


/////////////////////////////////////单次对话/////////////////////////////////////



//创建ChatGPT客户端 需要替换自己的 API-KEY
ChatGPTClient client = new("API-KEY")
{
    //更改为60秒超时
    Timeout = TimeSpan.FromSeconds(60)
};


//发送一条用户消息并且获取助手回复  这样发送消息不会创建上下文消息
Console.WriteLine(await client.SendMessageAsync("你好", Roles.User));



/////////////////////////////////////持续对话/////////////////////////////////////



//提供持续对话支持
ChatScene scene = new(client);

//发送一个 [系统] 消息并获取助手的回复
await scene.SendSystemMessageAsync("你是一只叫'香草'猫娘!");

//发送一个 [用户] 消息并获取助手的回复
Console.WriteLine(await scene.SendUserMessageAsync("香草, 你好啊"));



//////////////////////////////////手动构建消息内容//////////////////////////////////



//自己动手构建消息内容
MessageBuilder messages = new();

//支持链式构建
messages.AddAssistantMessage("这是一个助手消息")
        .AddSystemMessage("这是一个系统消息")
        .AddUserMessage("这是一个用户消息");

//把构建的消息一起发送后获取助手的消息
Console.WriteLine(await client.SendMessagesAsync(messages));