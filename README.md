# Ruby Language Service

[![Build status](https://ci.appveyor.com/api/projects/status/bn2pfammoonfe67y?svg=true)](https://ci.appveyor.com/project/madskristensen/rubylanguageservice)

This adds Ruby language support to Visual Studio 2017 Update 6.

![Ruby](src/Resources/Icon.png)

## Features

- Syntax highlighting
- Auto completion
- Outlining (code folding)
- Comment/uncomment commands

## Syntax highlighting
Any Ruby file get's syntax highlighting in the editor.

![Syntax highlighting](art/classification.png)

## Auto completion
Basic auto completion based on symbols in the same file is provided.

![Completion](art/completion.png)

## Outlining (code folding)
Collapse and expand the code baesd on indentation levels.

![Outlining](art/outlining.png)

## Comment/uncomment
Hit `CTRL+K,C` to turn the selection into a comment and `CTRL+K,U` to remove a comment.

## Credit
This extension is based on the [Ruby extension](https://github.com/rubyide/vscode-ruby) for Visual Studio Code.