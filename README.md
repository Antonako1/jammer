# <img src="https://raw.githubusercontent.com/jooapa/jammer/main/icons/trans_icon512x512.png" width="35px"> Jammer — light-weight TUI music player

![banner](.github/img/banner3.png)

## Introduction

Tired of opening up a browser or app to play music, and even then you can't
play local files or songs from different sites?

Jammer is a simple CLI music player that supports playing songs from your **local files**, **Youtube** and **Soundcloud**.

Compatible with **`Windows`**, *`Linux`*.

***Jammer shines its best when using it as a playlist. That's why I created it,
for the playlist feature across different platforms***

- The player doesn't stream the songs, but downloads them to local storage.
- The Jammer folder is located in the user's home directory and contains the
  downloaded songs, playlists, settings, keybinds, locales and effects modification.
- Jammer uses [Bass](https://www.un4seen.com/) for playing the songs and [ManagedBass](https://github.com/ManagedBass/ManagedBass) for being able to use it in .NET, [SoundCloudExplode](https://github.com/jerry08/SoundCloudExplode), [YoutubeExplode](https://github.com/Tyrrrz/YoutubeExplode) for downloading the songs and [Spectre.Console](https://github.com/spectreconsole/spectre.console) for the UI.

## Install/Update

### Install

Github latest [Release](https://github.com/jooapa/signal-Jammer/releases/latest)
Linux version of Jammer requires fuse2. Ubuntu 22.02 or newer install `apt
install libfuse2`.

Install without appimage, requires sudo privileges

```bash
curl -o InstallJammer.sh https://raw.githubusercontent.com/Jooapa/jammer/main/InstallJammer.sh
chmod +x InstallJammer.sh
sudo ./InstallJammer.sh
```

### Update existing

```bash
jammer update
```

## Usage

```bash
jammer
jammer [song] ... [folder]
jammer https://soundcloud.com/username/track-name
jammer https://soundcloud.com/username/sets/playlist-name
jammer https://youtube.com/watch?v=video-id
jammer https://youtube.com/playlist?list=playlist-id
jammer https://raw.githubusercontent.com/jooapa/jammer/main/npc_music/616845.mp3
jammer https://raw.githubusercontent.com/jooapa/jammer/main/example/terraria.jammer

jammer --start        opens jammer folder
jammer --update       checks for updates and installs
jammer --help -h      show help
jammer -d             debug mode
jammer --version      show version
```

*when using **Soundcloud** or **Youtube** **links** do not forget to use **`https://`** at the start.*

```bash
jammer -h, --help                         show this help message-
jammer -p, --play <name>                  play playlist
jammer -c, --create <name>                create playlist
jammer -d, --delete <name>                delete playlist
jammer -a, --add <name> <song> ...        add song to playlist
jammer -r, --remove <name> <song> ...     remove song from playlist
jammer -s, --show <name> 
jammer -l, --list                         list all playlists
jammer -f, --flush                        deletes all the songs in songs folder
jammer -sp, --set-path <path>, <default>  set path for songs folder
jammer -gp, --get-path                    get the path to the jammer/songs folder
jammer -hm, --home                        play all songs from the jammer/songs folder
```

### Example usage

```bash
jammer "path/to/song.mp3" "path/to/folder" C:\Users\user\jammer\playlists\playlist.jammer
```

```bash
jammer https://soundcloud.com/angry-birds-2009-2014/haunted-hogs https://soundcloud.com/angrysausage/sets/undertale-toby-fox
```

```bash
jammer https://www.youtube.com/watch?v=4zjFDTIROhQ
```

#### Example of making a playlist in cli

```bash
jammer -c new_playlist
jammer -a new_playlist https://www.youtube.com/playlist?list=PLnaJlq-zKc0WUXhwhSowwJdpe1fZumJzd
jammer -p new_playlist
```

*you can do same by opening `jammer`, pressing `shift + alt + s` and after that `shift + a` to add the playlist by input*

You can also use `-d` flag that will add logs to current folder.

---

### Supported formats

Jammer **supports** the following audio formats: ***.mp3***, ***.ogg***, ***.wav***, ***.mp2***, ***.mp1***, ***.aiff***, ***.m2a***, ***.mpa***, ***.m1a***, ***.mpg***, ***.mpeg***, ***.aif***, ***.mp3pro***, ***.bwf***, ***.mus***, ***.mod***, ***.mo3***, ***.s3m***, ***.xm***, ***.it***, ***.mtm***, ***.umx***, ***.mdz***, ***.s3z***, ***.itz***, ***.xmz***, ***.aac***, ***.adts***, ***.mp4***, ***.m4a***, ***.m4b***.

- **JAMMER** Jammer playlist
- **FOLDER** Folder/Directory (support playing all audio files within a folder)
- **YOUTUBE** Youtube video/playlist
- **SOUNDCLOUD** Soundcloud song/playlist

### Themes

You can create your own theme by pressing `Shift + T` (default keybing)

Select 'Create a New Theme' and write the theme's name. Go to `jammer/themes`, you should see `name.json`. It will contain all the information needed for creating a theme.

```
Colours: https://spectreconsole.net/appendix/colors and https://spectreconsole.net/appendix/styles
or see jammer\docs\console_styling.html

Write the colour's and styles' name in lowercase: ""white"", ""italic bold""
Example: ""PathColor"": ""red bold italic""
Note:    If you type """" as a colour's value, it will use the terminal's default color
Example: ""PathColor"": """"


Border Styles: https://spectreconsole.net/appendix/borders
or see jammer\docs\console_styling.html

Example: ""BorderStyle"": ""Rounded""
BorderColors are in RGB format: [0-255, 0-255, 0-255]
```

### Effects

- Reverb
- Echo
- Flanger
- Chorus
- Distortion
- Compressor
- Gargle
- Parametric Equalizer

Can be changed in the Effects.ini file in the Jammer folder.

### Default Player Controls

| Key | Action |
|  --------  |  -------  |
| `H` | Show/hide help |
| `C` | Show/hide settings |
| `F` | Show/hide playlist view |
| `Shift + E` | Edit keybindings|
| `Shift + L` | Change language|
| `Space` | Play/pause |
| `Q` | Quit |
| `→` | Forward |
| `←` | Backward |
| `↑` | Volume up |
| `↓` | Volume down |
| `M` | Mute/unmute |
| `L` | Toggle loop |
| `S` | Toggle shuffle |
| `R` | Play in random song |
| `N` | Next song in playlist |
| `P` | Previous song in playlist |
| `Delete` | Delete current song from playlist |
| `F2` | Show playlist options |
| `Tab` | Show CMD help screen|
| `0` | Goto start of the song|
| `9` | Goto end of the song|
| `Shift` + `Tab` | Change Theme|

### Default Playlist Controls

| Key | Action |
| ------ | ----------- |
| `Shift + A`| Add song to playlist |
| `Shift + D`| Show songs in other playlist |
| `Shift + F`| List all playlists |
| `Shift + O`| Play other playlist |
| `Shift + S`| Save playlist |
| `Shift + Alt + S`| Save as |
| `Alt + S`| Shuffle playlist |
| `Shift + P`| Play song(s) |
| `Shift + B`| Redownload current song |
| `Shift + Y`| Search YouTube for songs |

## Language support

Currently supported languages:

- English

- Finnish

Create new translation by copying already existing .ini file from /locales and translating it.

## Build / Run yourself

Download the **BASS** and **BASS_AAC** libraries from the [un4seen](http://www.un4seen.com/bass.html) website or the libaries are included in the libs folder.

On **Linux**, you need to add the libraries to the $LD_LIBRARY_PATH.

```bash
export LD_LIBRARY_PATH=/path/to/your/library:$LD_LIBRARY_PATH
```

On **Windows**, you need to add the libraries to the executable folder.

### Run

#### CLI

```bash
dotnet run --project Jammer.CLI -p:DefineConstants="CLI_UI" -- [args]
```

#### AVALONIA

```bash
dotnet run --project Jammer.Avalonia -p:DefineConstants="AVALONIA_UI" -- [args]
```

### Build

#### Windows

##### _CLI

```bash
dotnet publish -r win10-x64 -c Release /p:PublishSingleFile=true -p:DefineConstants="CLI_UI" --self-contained
```

##### _AVALONIA

```bash
dotnet publish -r win10-x64 -c Release /p:PublishSingleFile=true -p:DefineConstants="AVALONIA_UI" --self-contained
```

##### Linux

Add **BASS** and **BASS_AAC** libraries to the executable folder and to $LD_LIBRARY_PATH.

```bash
dotnet publish -r linux-x64 -c Release /p:PublishSingleFile=true -p:UseForms=false -p:DefineConstants="CLI_UI" --self-contained
```

```bash
dotnet publish -r linux-x64 -c Release /p:PublishSingleFile=true -p:UseForms=true -p:DefineConstants="AVALONIA_UI"
```

##### Linux AppImage release

AppImage requires fuse. To install fuse

```bash
sudo apt install libfuse2
```

To install appimagetool

```bash
wget https://github.com/AppImage/AppImageKit/releases/download/continuous/appimagetool-x86_64.AppImage
chmod 700 appimagetool-x86_64.AppImage
```

To create AppImage run `build.sh`

or if you want to build it from usb

```bash
sh -c "$(wget -O- https://raw.githubusercontent.com/jooapa/jammer/main/usb-appimage.sh)"
```

##### Build script for NSIS installer

you can use `update.py` to change the version of the app.

```bash
                 |-Major
                 ||--Minor
                 |||---Patch
python update.py 101
```

### Incoming Features

- [ ] Add more audio formats
