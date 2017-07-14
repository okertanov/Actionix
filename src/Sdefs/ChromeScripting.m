#import "Chrome.h"
#import "ChromeScripting.h"

static NSString* _chromeBundle;
static ChromeApplication* _chromeApplication;

@interface ChromeScripting()

@property (retain, nonatomic) NSString* chromeBundle;
@property (retain, nonatomic) ChromeApplication* chromeApplication;

@end

@implementation ChromeScripting

-(NSString*)chromeBundle {
    return _chromeBundle;
}

-(void)setChromeBundle:(NSString*)bundleName {
    _chromeBundle = bundleName;
}

-(ChromeApplication*)chromeApplication {
    return _chromeApplication;
}

-(void)setChromeApplication:(ChromeApplication*)app {
    _chromeApplication = app;
}

-(id)initWithBundleName:(NSString*)bundleName {
    self = [super init];
    if (self) {
        self.chromeBundle = bundleName;
        self.chromeApplication = [SBApplication applicationWithBundleIdentifier:self.chromeBundle];
    }
    return self;
}

-(void)activate {
    [self.chromeApplication activate];
    usleep(100000);
}

-(void)openTab:(NSString*)url {
    ChromeTab *tab = [[[self.chromeApplication classForScriptingClass:@"tab"] alloc] init];
    ChromeWindow *window = (ChromeWindow*)[self activeWindow];
    [window.tabs addObject:tab];
    if ([url length] != 0) {
        tab.URL = url;
    }
}

-(SBObject*)activeTab {
    return ((ChromeWindow*)[self activeWindow]).activeTab;
}

- (SBObject*)activeWindow {
    ChromeWindow* window = self.chromeApplication.windows.firstObject;

    if (!window) {
        window = [[[self.chromeApplication classForScriptingClass:@"window"] alloc] init];
        [self.chromeApplication.windows addObject:window];
    }

    return window;
}

-(NSArray<NSObject*>*)allTabs {
    ChromeWindow *window = (ChromeWindow*)[self activeWindow];
    NSMutableArray<NSObject*>* tabNames = [[NSMutableArray<NSObject*> alloc] init];
    for (ChromeTab* tab in window.tabs) {
        //ChromeTabInfo* info = [[ChromeTabInfo alloc] init];
        //info.title = [[NSString alloc] initWithString:tab.title];
        [tabNames addObject:tab.title];
    }
    return tabNames;
}

@end
