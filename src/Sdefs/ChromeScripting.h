#import <Foundation/Foundation.h>
#import "Chrome.h"

@interface ChromeScripting : NSObject

@property (weak, nonatomic) NSString* chromeBundle;
@property (weak, nonatomic) ChromeApplication* chromeApplication;

-(id)initWithBundleName:(NSString *)bName;
-(void)activate;
-(void)openTab:(NSString*)url;

- (ChromeTab *)activeTab;
- (ChromeWindow *)activeWindow;

@end

