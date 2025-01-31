﻿namespace RxBim.Sample.Application.Menu.Fluent.Autocad
{
    using Commands;
    using Di;
    using RxBim.Application.Ribbon;

    /// <inheritdoc />
    public class Config : IApplicationConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            container.AddAutocadMenu(ribbon =>
                ribbon
                    .EnableDisplayVersion()
                    .SetVersionPrefix("Version: ")
                    .Tab(
                        title: "RxBim_Tab_FromAction",
                        tab => tab
                            .Panel(
                                title: "RxBim_Panel_1",
                                panel => panel
                                    .CommandButton(
                                        "Command1_Large_WithText",
                                        typeof(Cmd1),
                                        button => button
                                            .ToolTip("Tooltip: I'm run command #1. Push me!")
                                            .Description("Description: This is command #1")
                                            .SmallImage(@"img.num1_16.png", ThemeType.Dark)
                                            .SmallImage(@"img.num1_16_light.png", ThemeType.Light)
                                            .LargeImage(@"img.num1_32.png", ThemeType.Dark)
                                            .LargeImage(@"img.num1_32_light.png", ThemeType.Light)
                                            .HelpUrl("https://github.com/ReactiveBIM/RxBim")
                                            .Text("Command\n#1"))
                                    .CommandButton(
                                        "Command2_Large_WithText",
                                        typeof(Cmd2),
                                        button => button
                                            .ToolTip("Tooltip: I'm run command #2. Push me!")
                                            .Description("Description: This is command #2")
                                            .SmallImage(@"img.num2_16.bmp", ThemeType.Dark)
                                            .SmallImage(@"img.num2_16_light.bmp", ThemeType.Light)
                                            .LargeImage(@"img.num2_32.bmp", ThemeType.Dark)
                                            .LargeImage(@"img.num2_32_light.bmp", ThemeType.Light)
                                            .HelpUrl("https://www.google.com/")
                                            .Text("Command\n#2"))
                                    .CommandButton(
                                        "Command3_Large_WithText",
                                        typeof(Cmd3),
                                        button => button
                                            .ToolTip("Tooltip: I'm run command #3. Push me!")
                                            .Description("Description: This is command #3")
                                            .SmallImage(@"img.num3_16.jpg", ThemeType.Dark)
                                            .SmallImage(@"img.num3_16_light.jpg", ThemeType.Light)
                                            .LargeImage(@"img.num3_32.jpg", ThemeType.Dark)
                                            .LargeImage(@"img.num3_32_light.jpg", ThemeType.Light)
                                            .HelpUrl("https://www.autodesk.com/")
                                            .Text("Command\n#3"))
                                    .Separator()
                                    .PullDownButton(
                                        "Pulldown1",
                                        pulldown => pulldown
                                            .CommandButton(
                                                "Command #1",
                                                typeof(Cmd1),
                                                button => SetupCommand1Button(button).Text("Command\n#1"))
                                            .CommandButton(
                                                "Command #2",
                                                typeof(Cmd2),
                                                button => SetupCommand2Button(button).Text("Command\n#2"))
                                            .CommandButton(
                                                "Command #3",
                                                typeof(Cmd3),
                                                button => SetupCommand3Button(button).Text("Command\n#3"))
                                            .LargeImage(@"img.command_32.ico", ThemeType.Dark)
                                            .LargeImage(@"img.command_32_light.ico", ThemeType.Light)
                                            .Text("Pulldown #1"))
                                    .SlideOut()
                                    .CommandButton(
                                        "Command1_Large_SlideOut",
                                        typeof(Cmd1),
                                        button => SetupCommand1Button(button).Text("Command\n#1"))
                                    .CommandButton(
                                        "Command2_Large_SlideOut",
                                        typeof(Cmd2),
                                        button => SetupCommand2Button(button).Text("Command\n#2"))
                                    .CommandButton(
                                        "Command3_Large_SlideOut",
                                        typeof(Cmd3),
                                        button => SetupCommand3Button(button).Text("Command\n#3")))
                            .Panel("RxBim_Panel_2",
                                panel => panel
                                    .StackedItems(items => items
                                        .CommandButton(
                                            "Command1_Small_WithText",
                                            typeof(Cmd1),
                                            button => SetupCommand1Button(button).Text("Command #1"))
                                        .CommandButton(
                                            "Command2_Small_WithText",
                                            typeof(Cmd2),
                                            button => SetupCommand2Button(button).Text("Command #2"))
                                        .CommandButton(
                                            "Command3_Small_WithText",
                                            typeof(Cmd3),
                                            button => SetupCommand3Button(button).Text("Command #3")))
                                    .Separator()
                                    .StackedItems(items => items
                                        .CommandButton(
                                            "Command1_Large_WithText",
                                            typeof(Cmd1),
                                            button => SetupCommand1Button(button).Text("Command\n#1"))
                                        .CommandButton(
                                            "Command2_Large_WithText",
                                            typeof(Cmd2),
                                            button => SetupCommand2Button(button).Text("Command\n#2")))
                                    .Separator()
                                    .StackedItems(items => items
                                        .PullDownButton(
                                            "Pulldown2",
                                            pulldown => pulldown
                                                .SmallImage(@"img.command_16.ico", ThemeType.Dark)
                                                .SmallImage(@"img.command_16_light.ico", ThemeType.Light)
                                                .CommandButton(
                                                    "Command #1",
                                                    typeof(Cmd1),
                                                    button => SetupCommand1Button(button))
                                                .CommandButton(
                                                    "Command #2",
                                                    typeof(Cmd2),
                                                    button => SetupCommand2Button(button))
                                                .CommandButton(
                                                    "Command #3",
                                                    typeof(Cmd3),
                                                    button => SetupCommand3Button(button)))
                                        .CommandButton(
                                            "Command1_Small",
                                            typeof(Cmd1),
                                            button => SetupCommand1Button(button))
                                        .CommandButton(
                                            "Command2_Small",
                                            typeof(Cmd2),
                                            button => SetupCommand2Button(button)))))
                .Tab(
                        title: "RxBim_Tab_FromAttributes",
                        tab => tab
                            .Panel(
                                title: "RxBim_Panel_1",
                                panel => panel
                                    .CommandButton<Cmd1>("Command1_Large_WithText")
                                    .CommandButton<Cmd2>("Command2_Large_WithText")
                                    .CommandButton<Cmd3>("Command3_Large_WithText")
                                    .Separator()
                                    .PullDownButton(
                                        "Pulldown1",
                                        pulldown => pulldown
                                            .LargeImage(@"img.command_32.ico", ThemeType.Dark)
                                            .LargeImage(@"img.command_32_light.ico", ThemeType.Light)
                                            .Text("Pulldown #1")
                                            .CommandButton<Cmd1>("Command #1")
                                            .CommandButton<Cmd2>("Command #2")
                                            .CommandButton<Cmd3>("Command #3"))
                                    .SlideOut()
                                    .CommandButton<Cmd1>("Command1_Large_SlideOut")
                                    .CommandButton<Cmd2>("Command2_Large_SlideOut")
                                    .CommandButton<Cmd3>("Command3_Large_SlideOut"))
                            .Panel("RxBim_Panel_2",
                                panel => panel
                                    .StackedItems(items => items
                                        .CommandButton<Cmd1>("Command1_Small_WithText")
                                        .CommandButton<Cmd2>("Command2_Small_WithText")
                                        .CommandButton<Cmd3>("Command3_Small_WithText"))
                                    .Separator()
                                    .StackedItems(items => items
                                        .CommandButton<Cmd1>("Command1_Large_WithText")
                                        .CommandButton<Cmd2>("Command2_Large_WithText"))
                                    .Separator()
                                    .StackedItems(items => items
                                        .PullDownButton(
                                            "Pulldown2",
                                            pulldown => pulldown
                                                .SmallImage(@"img.command_16.ico", ThemeType.Dark)
                                                .SmallImage(@"img.command_16_light.ico", ThemeType.Light)
                                                .CommandButton<Cmd1>("Command #1")
                                                .CommandButton<Cmd2>("Command #2")
                                                .CommandButton<Cmd3>("Command #3"))
                                        .CommandButton<Cmd1>("Command1_Small")
                                        .CommandButton<Cmd2>("Command2_Small")))));
        }

        private static TButtonBuilder SetupCommand1Button<TButtonBuilder>(TButtonBuilder button)
            where TButtonBuilder : class, IButtonBuilder<TButtonBuilder>
        {
            return button
                .ToolTip("Tooltip: I'm run command #1. Push me!")
                .Description("Description: This is command #1")
                .SmallImage(@"img.num1_16.png", ThemeType.Dark)
                .SmallImage(@"img.num1_16_light.png", ThemeType.Light)
                .LargeImage(@"img.num1_32.png", ThemeType.Dark)
                .LargeImage(@"img.num1_32_light.png", ThemeType.Light)
                .HelpUrl("https://github.com/ReactiveBIM/RxBim");
        }

        private static TButtonBuilder SetupCommand2Button<TButtonBuilder>(TButtonBuilder button)
            where TButtonBuilder : class, IButtonBuilder<TButtonBuilder>
        {
            return button
                .ToolTip("Tooltip: I'm run command #2. Push me!")
                .Description("Description: This is command #2")
                .SmallImage(@"img.num2_16.bmp", ThemeType.Dark)
                .SmallImage(@"img.num2_16_light.bmp", ThemeType.Light)
                .LargeImage(@"img.num2_32.bmp", ThemeType.Dark)
                .LargeImage(@"img.num2_32_light.bmp", ThemeType.Light)
                .HelpUrl("https://www.google.com/");
        }

        private static TButtonBuilder SetupCommand3Button<TButtonBuilder>(TButtonBuilder button)
            where TButtonBuilder : class, IButtonBuilder<TButtonBuilder>
        {
            return button
                .ToolTip("Tooltip: I'm run command #3. Push me!")
                .Description("Description: This is command #3")
                .SmallImage(@"img.num3_16.jpg", ThemeType.Dark)
                .SmallImage(@"img.num3_16_light.jpg", ThemeType.Light)
                .LargeImage(@"img.num3_32.jpg", ThemeType.Dark)
                .LargeImage(@"img.num3_32_light.jpg", ThemeType.Light)
                .HelpUrl("https://www.autodesk.com/");
        }
    }
}