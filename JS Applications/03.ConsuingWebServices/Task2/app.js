/*
 * ### HOW TO CREATE A VALID ID TO USE: ###
 * Go to www.twitter.com and sign in as normal, go to your settings page.
 * Go to "Widgets" on the left hand side.
 * Create a new widget for what you need eg "user timeline" or "search" etc.
 * Feel free to check "exclude replies" if you dont want replies in results.
 * Now go back to settings page, and then go back to widgets page, you should
 * see the widget you just created. Click edit.
 * Now look at the URL in your web browser, you will see a long number like this:
 * 345735908357048478
 * Use this as your ID below instead!
 */

/**
 * How to use fetch function:
 * @param {string} Your Twitter widget ID.
 * @param {string} The ID of the DOM element you want to write results to. 
 * @param {int} Optional - the maximum number of tweets you want returned. Must
 *     be a number between 1 and 20.
 * @param {boolean} Optional - set true if you want urls and hash
       tags to be hyperlinked!
 * @param {boolean} Optional - Set false if you dont want user photo /
 *     name for tweet to show.
 * @param {boolean} Optional - Set false if you dont want time of tweet
 *     to show.
 * @param {function/string} Optional - A function you can specify to format
 *     tweet date/time however you like. This function takes a JavaScript date
 *     as a parameter and returns a String representation of that date.
 *     Alternatively you may specify the string 'default' to leave it with
 *     Twitter's default renderings.
 * @param {boolean} Optional - Show retweets or not. Set false to not show.
 * @param {function/string} Optional - A function to call when data is ready. It
 *     also passes the data to this function should you wish to manipulate it
 *     yourself before outputting. If you specify this parameter you  must
 *     output data yourself!
 * @param {boolean} Optional - Show links for reply, retweet, favourite. Set false to not show.
 */

// ##### Simple example 1 #####
// A simple example to get Nakov's latest tweet and write to a HTML element with
// id "tweets". Also automatically hyperlinks URLS and user mentions and
// hashtags.
twitterFetcher.fetch('493040084006887425', 'example1', 1, true);


// ##### Simple example 2 #####
// A simple example to get Nakov's latest 5 favourite tweets and write to a HTML
// element with id "talk". Also automatically hyperlinks URLS and user mentions and
// hashtags but does not display time of post.
twitterFetcher.fetch('493040084006887425', 'example2', 5, true, true, false);


// Doncho Minkov's last tweet.
twitterFetcher.fetch('493167637740802048', 'example3', 1, true);

// Minkov's last 10 tweets.
twitterFetcher.fetch('493167637740802048', 'example4', 10, true, true, false);