#import <Foundation/Foundation.h>

@interface ChromeScripting : NSObject

-(id)initWithBundleName:(NSString *)bundleName;
-(void)activate;
-(void)openTab:(NSString*)url;

@end
