#import "Chrome.h"
#import "ChromeScripting.h"

@interface ChromeScripting()

@property (retain, nonatomic) NSString* chromeBundle;
@property (retain, nonatomic) ChromeApplication* chromeApplication;

@end

@implementation ChromeScripting

@synthesize chromeBundle;
@synthesize chromeApplication;

-(id)initWithBundleName:(NSString *)bundleName
{
    self = [super init];
    if (self)
    {
        self.chromeBundle = bundleName;
        self.chromeApplication = [SBApplication applicationWithBundleIdentifier:self.chromeBundle];
    }
    return self;
}

-(void)activate
{
    [self.chromeApplication activate];
    usleep(100000);
}

-(void)openTab:(NSString*)url
{
    ChromeTab *tab = [[[self.chromeApplication classForScriptingClass:@"tab"] alloc] init];
    ChromeWindow *window = [self activeWindow];
    [window.tabs addObject:tab];
    if ([url length] != 0) {
        tab.URL = url;
    }
}

- (ChromeTab *)activeTab {
    return [self activeWindow].activeTab;
}

- (ChromeWindow *)activeWindow {
    ChromeWindow *window = self.chromeApplication.windows.firstObject;

    if (!window) {
        window = [[[self.chromeApplication classForScriptingClass:@"window"] alloc] init];
        [self.chromeApplication.windows addObject:window];
    }

    return window;
}

@end

