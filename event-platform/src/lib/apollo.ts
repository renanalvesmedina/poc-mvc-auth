import { ApolloClient, InMemoryCache } from "@apollo/client";

export const client = new ApolloClient({
  uri: 'https://api-sa-east-1.graphcms.com/v2/cl4rhujvw12pb01yxeait5ijc/master',
  cache: new InMemoryCache()
});