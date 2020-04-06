FROM mono:6.8.0
RUN apt-get update \
&& apt-get install unzip \
&& cd home \
# Get Nuget and Microsoft.Build to make it work
&& curl -o nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe \
&& curl -o Microsoft.Build.zip https://headsigned.com/posts/running-nuget-command-line-on-linux/Microsoft.Build.zip \
&& unzip Microsoft.Build.zip \
&& rm Microsoft.Build.zip \
# Get NUnit and chromedriver
&& mono nuget.exe install NUnit \
&& mono nuget.exe install NUnit.Runners \
&& curl -o chromedriver_linux64.zip https://chromedriver.storage.googleapis.com/80.0.3987.106/chromedriver_linux64.zip \
&& unzip chromedriver_linux64.zip \
&& rm chromedriver_linux64.zip \
# Get sample project and build it
# && git install
# && git checkout
# && msbuild 
# Run tests
&& mono NUnit.ConsoleRunner.3.10.0/tools/nunit3-console.exe ~/Downloads/Debug/TestFrame.TestsNet.dll -noresult
