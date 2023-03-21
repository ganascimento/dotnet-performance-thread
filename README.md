# Dotnet Performance Test - Threads

## About

This project was developed to test performance with thread and different types of thread implementation.

The function to get prime numbers in a range from 100 to 1000000 was used to test the performance, and the results were very interesting

Tests were run on a machine with:

- Win11
- Processor: i7
- Ram: 16gb

### No use thread

```
 PrimeNumberV1:
 Time: 21257ms
```

### Manual implementation

```
 PrimeNumberV2:
 Time: 3591ms
```

### ThreadPool

```
 PrimeNumberV3:
 Time: 2832ms
```

### Parallel.For

```
 PrimeNumberV4:
 Time: 2829ms
```

In test 4 there is no significant difference in performance from test 3, but the implementation is simpler, while test 3 is more complex
