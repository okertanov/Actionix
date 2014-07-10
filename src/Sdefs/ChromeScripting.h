#import <Foundation/Foundation.h>
#import "Chrome.h"

@interface ChromeScripting : NSObject
{
    NSString* chromeBundle;
    ChromeApplication* chromeApplication;
}

@property (retain, nonatomic) NSString* chromeBundle;
@property (retain, nonatomic) ChromeApplication* chromeApplication;

-(id)initWithBundleName:(NSString *)bName;
-(void)activate;
-(void)openTab:(NSString*)url;

- (ChromeTab *)activeTab;
- (ChromeWindow *)activeWindow;

@end

