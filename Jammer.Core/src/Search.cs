using Spectre.Console;

namespace Jammer
{
    public static class Search
    {
        public static void SearchSong() {
            string platform = Message.Input("Type 'y' for [red]Youtube[/] or 's' for [darkorange]SoundCloud[/]:", "Search for a song on Youtube or SoundCloud");
            platform = platform.ToLower();

            if (platform == "youtube" || platform == "y") {
                string type = Message.Input("Type 'v|t' for Video or 'p' for Playlist:", "[red]Youtube[/] Search for a Video|Track or Playlist? ");
                type = type.ToLower();

                if (type == "video" || type == "v" || type == "track" || type == "t") {
                    SearchYTSong("video");
                } else if (type == "playlist" || type == "p") {
                    SearchYTSong("playlist");
                }
            } else if (platform == "soundcloud" || platform == "s") {
                string type = Message.Input("Type 't' for Track or 'p' for Playlist:","[darkorange]Soundcloud[/] Search for a Track or Playlist?");
                type = type.ToLower();

                if (type == "track" || type == "t") {
                    SearchSCSong("track");
                } else if (type == "playlist" || type == "p") {
                    SearchSCSong("playlist");
                }
            }
        }
        public static void SearchYTSong(string type) {
            // TODO ADD LOCALE(s)
            string search = Message.Input("Search:", "Search a song from Youtube by its name");

            List<YTSearchResult> results = new();
            int indexer = 0;
            int max = 10;
            async Task loopedidoo() {
                if (type == "playlist") {
                    await foreach (var result in Download.youtube.Search.GetPlaylistsAsync(search)) {
                        var id = result.Id;
                        var title = Markup.Escape(result.Title);
                        string type = "playlist";
                        results.Add(new YTSearchResult { Id = id, Title = title, Type = type });

                        if (indexer == max - 1) {
                            break;
                        }
                        indexer++;
                    }
                } else if (type == "video") {
                    await foreach (var result in Download.youtube.Search.GetVideosAsync(search)) {
                        var id = result.Id;
                        var title = Markup.Escape(result.Title);
                        string type = "video";
                        results.Add(new YTSearchResult { Id = id, Title = title, Type = type });

                        if (indexer == max - 1) {
                            break;
                        }
                        indexer++;
                    }
                }
            }
            loopedidoo().Wait();

            if (results.Count > 0) {
                string[] resultsString = results.Select(r => Markup.Escape(r.Type + ": " + r.Title)).ToArray();
                resultsString = new[] { "Cancel" }.Concat(resultsString).ToArray();
                // Display the MultiSelect prompt after the loop completes
                AnsiConsole.Clear();
                string answer = Message.MultiSelect(resultsString, "Search results for '" + search + "' on youtube: " + results.Count + "/" + max);

                // Get the id of the selected song
                string selectedId = "";
                string selectedString = "";
                try{
                    selectedId = results[Array.IndexOf(resultsString, answer)].Id;
                    selectedString = results[Array.IndexOf(resultsString, answer)].Title;
                } catch {
                    // If the user cancels the selection
                    /*
                    Unhandled exception. System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
                    at System.Collections.Generic.List`1.get_Item(Int32 index)
                    at Jammer.Start.CheckKeyboardAsync() in C:\Users\%USERNAME%\Documents\GitHub\jammer\Jammer.Core\src\Keyboard.cs:line 495
                    at Jammer.Start.Loop() in C:\Users\%USERNAME%\Documents\GitHub\jammer\Jammer.Core\src\Start.cs:line 373
                    */
                    Start.drawWhole = true;
                    return;
                }
                string url = "https://www.youtube.com/watch?v=" + selectedId + "½" + selectedString;
                
                // add to the current playlist index +1
                Play.AddSong(url);
            } else {
                Message.Data("No results found", ":(");
            }
            Start.drawWhole = true;
        }
        public static void SearchSCSong(string type) {
            // TODO ADD LOCALE(s)
            string search = Message.Input("Search:", "Search a song from SoundCloud by its name");

            List<SCSearchResult> results = new();
            int indexer = 0;
            int max = 10;
            async Task loopedidoo() {
                if (type == "playlist") {
                    await foreach (var result in Download.soundcloud.Search.GetPlaylistsAsync(search)) {
                        var url = result.Url;
                        var title = Markup.Escape(result.Title);
                        results.Add(new SCSearchResult { Url = url, Title = title});

                        if (indexer == max - 1) {
                            break;
                        }
                        indexer++;
                    }
                } else if (type == "track") {
                    await foreach (var result in Download.soundcloud.Search.GetTracksAsync(search)) {
                        var url = result.Url;
                        var title = Markup.Escape(result.Title);
                        results.Add(new SCSearchResult { Url = url, Title = title});

                        if (indexer == max - 1) {
                            break;
                        }
                        indexer++;
                    }
                }
            }
            loopedidoo().Wait();

            if (results.Count > 0) {
                string[] resultsString = results.Select(r => Markup.Escape(r.Title)).ToArray();
                resultsString = new[] { "Cancel" }.Concat(resultsString).ToArray();
                // Display the MultiSelect prompt after the loop completes
                AnsiConsole.Clear();
                string answer = Message.MultiSelect(resultsString, "Search results for '" + search + "' on SoundCloud: " + results.Count + "/" + max);

                // Get the url of the selected song
                string selectedUrl = "";
                string selectedString = "";
                try{
                    selectedUrl = results[Array.IndexOf(resultsString, answer)].Url;
                    selectedString = results[Array.IndexOf(resultsString, answer)].Title;
                } catch {
                    // If the user cancels the selection
                    /*
                    Unhandled exception. System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
                    at System.Collections.Generic.List`1.get_Item(Int32 index)
                    at Jammer.Start.CheckKeyboardAsync() in C:\Users\%USERNAME%\Documents\GitHub\jammer\Jammer.Core\src\Keyboard.cs:line 495
                    at Jammer.Start.Loop() in C:\Users\%USERNAME%\Documents\GitHub\jammer\Jammer.Core\src\Start.cs:line 373
                    */
                    Start.drawWhole = true;
                    return;
                }
                string url = selectedUrl + "½" + selectedString;
                
                // add to the current playlist index +1
                Play.AddSong(url);
            } else {
                Message.Data("No results found", ":(");
            }
            Start.drawWhole = true;
        }
    }
}