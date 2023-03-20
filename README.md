# Easy.ChatGPT
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FDaThabe%2FEasy.ChatGPT.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FDaThabe%2FEasy.ChatGPT?ref=badge_shield)


一个简单调用ChatGPT API 的实现

## 用法演示

### Using
``` C#
using Thabe.Kit.EasyChatGPT;
using Thabe.Kit.EasyChatGPT.Model.Data;
```

### 单次对话
``` C#
//创建ChatGPT客户端 需要替换自己的 API-KEY
ChatGPTClient client = new("API_KEY");

//发送一条用户消息并且获取助手回复  这样发送消息不会创建上下文消息
Console.WriteLine(await client.SendMessageAsync("你好", Roles.User));
```


### 持续对话
```C#
//提供持续对话支持
ChatScene scene = new(client);

//发送一个 [系统] 消息并获取助手的回复
await scene.SendSystemMessageAsync("你是一只叫'香草'猫娘!");

//发送一个 [用户] 消息并获取助手的回复
Console.WriteLine(await scene.SendUserMessageAsync("香草, 你好啊"));
```

### 手动构建消息内容
```C#
//自己动手构建消息内容
MessageBuilder messages = new();

//支持链式构建
messages.AddAssistantMessage("这是一个助手消息")
        .AddSystemMessage("这是一个系统消息")
        .AddUserMessage("这是一个用户消息");

//把构建的消息一起发送后获取助手的消息
Console.WriteLine(await client.SendMessagesAsync(messages));
```

## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FDaThabe%2FEasy.ChatGPT.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FDaThabe%2FEasy.ChatGPT?ref=badge_large)