#import <Foundation/Foundation.h>
#import "Chrome.h"

@interface ChromeScripting : NSObject
{
    NSString* chromeBundle;
    ChromeApplication* chromeApplication;
}

-(id)initWithBundleName:(NSString *)bundleName;
-(void)activate;
-(void)openTab:(NSString*)url;

@end

